import { useLocation, Link } from "react-router-dom";
import useAuth from '../../hooks/useAuth';


function CertificateDetails() {

    var count = 1;
    const location = useLocation();
    const certificates = location.state.certificateDetails;
    const { auth } = useAuth();


    return (
        <div>
            <h1>Certificate Details</h1>

            <div className="container col-sm-10">

                <hr />
                <dl className="row">
                    <dt className="col-sm-2">Certificate Title</dt>
                    <dd className="col-sm-10">{certificates.title}</dd>
                </dl>

                <hr />

                {certificates.topics.map((topic) => (
                    <div key={topic.topicId}>

                        <dt className="col-sm-2">Topic Title</dt>
                        <dd className="col-sm-10">{topic.topicDescription}</dd>
                        <dt className="col-sm-2">Topic Id</dt>
                        <dd className="col-sm-10">{topic.topicId}</dd>
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