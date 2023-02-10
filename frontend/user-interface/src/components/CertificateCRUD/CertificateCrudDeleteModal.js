import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';

function CertificateCrudDeleteModal(props) 
{
    return (
    <>
     <Modal show={props.showModal} onHide={()=>{props.closeConfirmPopupHandler()}}>
        <Modal.Header closeButton>
          <Modal.Title>Modal {props.Title}</Modal.Title>
        </Modal.Header>
        <Modal.Body>{props.body}</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={()=>{props.closeConfirmPopupHandler()}}>
            Close
          </Button>
          <Button variant="danger" onClick={()=>{props.deleteConfirmHandler()}}>  
             Confirm Delete
          </Button>
        </Modal.Footer>
      </Modal>
    </>
    )
}

export default CertificateCrudDeleteModal;