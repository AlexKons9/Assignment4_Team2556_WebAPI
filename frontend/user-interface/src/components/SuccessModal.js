import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';

function SuccessModal(props) 
{
    return (
    <>
     <Modal show={props.showModal} onHide={()=>{props.closeConfirmPopupHandler()}}>
        <Modal.Header closeButton>
          <Modal.Title>{props.title}</Modal.Title>
        </Modal.Header>
        <Modal.Body>{props.body}</Modal.Body>
      </Modal>
    </>
    )
}

export default SuccessModal;