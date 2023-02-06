import React, { useState } from 'react';
import Alert from 'react-bootstrap/Alert';
import Button from 'react-bootstrap/Button';

function SuccessModal(props) {

  return (
    <>
      <Alert show={props.show} variant="success" >
        <Alert.Heading>Success</Alert.Heading>
        <p>
          {props.body}
        </p>
        <hr />
        <div className="d-flex justify-content-end">
          <Button onClick={() => props.closeModalHandler()} variant="outline-success">
            Close
          </Button>
        </div>
      </Alert>
    </>
  );
}

export default SuccessModal;