import React, { useRef } from 'react';
import emailjs from '@emailjs/browser';
import './RequestEmail.css'

const RequestEmail = ({openEmailRequest, setOpenEmail}) => {
  const form = useRef();

  const sendEmail = (e) => {
    e.preventDefault();

    emailjs
      .sendForm('service_12t1pkv', 'template_qq2gqwf', form.current, {
        publicKey: 'ihrMv_2LLSM4_rNIE',
      })
      .then(
        () => {
          console.log('SUCCESS!');
        },
        (error) => {
          console.log('FAILED...', error.text);
        },
      );
  };
  
  const handleClose = () => {
    setOpenEmail(false);
  }
  
  return (
    <div>
        <div className="proceed-entering">
          <h4 className="proceed-entering-header">Enter details to get an email containing your User Identification number
            <button className="close-button" button="button-type" onClick={handleClose}>×</button>
          </h4>
        </div>    
      <form ref={form} onSubmit={sendEmail} className='email-js-form'>

        <label>Name</label>
        <input type="text"  className="email-name-input" name="from_name" />
        <label>Email</label>
        <input type="email"   className="email-name-input" name="from_email" />
        {/* <label>Message</label>
        <input name="message" /> */}
        <input type="submit" className='button-type' value="Send" />
      </form>
    </div>
  );
};

export default RequestEmail