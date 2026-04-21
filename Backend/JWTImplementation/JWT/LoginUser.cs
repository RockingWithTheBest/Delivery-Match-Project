using Backend.DatabasContext;
using Backend.Models;
using Microsoft.AspNetCore.Identity;

namespace Backend.Microservice.JWT
{
    public sealed class LoginUser
    {
        private readonly ApplicationDatabaseContext context;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly TokenProvider tokenProvider;

        public LoginUser(ApplicationDatabaseContext context, IPasswordHasher<User> passwordHasher, TokenProvider tokenProvider)
        {
            this.context = context;
            this.passwordHasher = passwordHasher;
            this.tokenProvider = tokenProvider;
        }

        public sealed record Request(string Email, string Password);

        public string Handle(Request request)
        {
            User user = context.Users.Where(i => i.Email == request.Email).FirstOrDefault();

            if (user == null)   
            {
                throw new Exception("User not found");
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                throw new Exception("The user doesn't contain an email address.");
            }

            // Verify password using IPasswordHasher
            var result = passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);
            
            if(result == PasswordVerificationResult.Failed)
            {
                throw new Exception("The password is incorrect");
            }

            // Optional: If password needs rehashing (outdated algorithm), update it
            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                // Rehash the password with current algorithm
                user.Password = passwordHasher.HashPassword(user, request.Password);
                context.SaveChanges(); // Save the updated hash
            }

            string token = tokenProvider.Create(user);
            return token;
        }
    }
}
