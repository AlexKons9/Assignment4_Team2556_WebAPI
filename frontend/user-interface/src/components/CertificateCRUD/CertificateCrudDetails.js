import { useLocation, Link } from "react-router-dom";
import useAuth from '../../hooks/useAuth';


function CertificateDetails() {

    var count = 1;
    const location = useLocation();
    const certificates = location.state.certificateDetails;
    const { auth } = useAuth();


    return (
        <div className="container col-sm-10">
            <h1>Details</h1>

            <div className="mt-3">
                <h4 className="mt-5">Certificate: </h4>
                <hr />
                <dl className="row">
                    <dt className="col-sm-6 text-center">Certificate Title</dt>
                    <dd className="col-sm-6 text-center">{certificates.title}</dd>
                </dl>
                <hr />
                <h4 className="mt-5">Topics: </h4>
                <hr />
                
                {certificates.topics.map((topic) => (
                    <div className= "row" key={topic.topicId}>
                        {/* <dt className="col-sm-6 text-center">Topic Id</dt>
                        <dd className="col-sm-6 text-center">{topic.topicId}</dd> */}
                        <dt className="col-sm-6 text-center">Topic Title</dt>
                        <dd className="col-sm-6 text-center">{topic.topicDescription}</dd>
                        <hr />
                    </div>
                ))}


                <div>
                    <Link className='btn btn-secondary' to={auth?.roles == "Admin" ? "../AdminUI/Certificates" : "/QualityControlUI/CertificateList"}>Back to List</Link>
                </div>

            </div>
        </div>
    );
}

export default CertificateDetails;