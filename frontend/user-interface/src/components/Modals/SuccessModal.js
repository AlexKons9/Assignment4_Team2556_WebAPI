import React, { useState } from 'react';
import Alert from 'react-bootstrap/Alert';
import Button from 'react-bootstrap/Button';

function SuccessModal(props) {

  return (
    <div className='col-md-4 container-fluid justify-content-center'>
      <Alert show={props.show} variant="success" >
        <Alert.Heading>Success</Alert.Heading>
        <hr />
        <p>
          {props.body}
        </p>
        <div className="d-flex justify-content-end">
          {props.buttonForModal}
          <Button onClick={() => props.closeModalHandler()} variant="outline-secondary">
            Close
          </Button>
        </div>
      </Alert>
    </div>
  );
}

export default SuccessModal;