FROM node:22-alpine

WORKDIR /app

COPY package*.json .

RUN npm install

COPY . .

EXPOSE 4606

# Use this for Vite (create-react-app alternative)
CMD ["npm", "run", "dev:docker"]
