import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';



function CertificateCard (props) {
  return (
    <Card className='col-md-4 certificate-card' style={{ width: '18rem' }}>
      <Card.Img variant="top" src={props.imgSrc} />
      <Card.Body>
        <Card.Title>{props.title}</Card.Title>
        <Card.Text>
            {props.textBody}
        </Card.Text>
        <button className="btn btn-outline-success" onClick={()=>{props.purchaseConfirmHandler(props.candidateId, props.userName)}}>Purchase: 10 Credits</button>
      </Card.Body>
    </Card>
  );
}

export default CertificateCard;