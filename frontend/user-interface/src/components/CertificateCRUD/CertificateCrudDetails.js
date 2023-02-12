import { useLocation, Link } from "react-router-dom";
import useAuth from '../../hooks/useAuth';


function CertificateDetails() {

    const count = 1;
    const location = useLocation();
    const certificates = location.state.certificateDetails;
    const { auth } = useAuth();


    return (
        <div className="container col-sm-10">
            <h1>Details</h1>

            <div className="mt-3">
                <h4 className="mt-5 mb-3">Certificate</h4>
                <table className="table table-bordered table-centered">
                    <tbody>
                        <tr>
                            <th className="col-6">Title</th>
                            <td className="col-6">{certificates.title}</td>
                        </tr>
                    </tbody>
                </table>
                <h4 className="mt-5 mb-3">Topics</h4>

                <table className="table table-bordered table-centered">
                    <tbody>

                        {certificates.topics.map((topic, count) => (
                            <tr key={topic.topicId}>
                                <th className="col-sm-6 text-center">Topic {++count}</th>
                                <td className="col-sm-6 text-center">{topic.topicDescription}</td>
                            </tr>                        
                        ))}
                    </tbody>
                </table>

                <div>
                    <Link className='btn btn-outline-secondary' to={auth?.roles == "Admin" ? "../AdminUI/Certificates" : "/QualityControlUI/CertificateList"}>Back to List</Link>
                </div>

            </div>
        </div>
    );
}

export default CertificateDetails;