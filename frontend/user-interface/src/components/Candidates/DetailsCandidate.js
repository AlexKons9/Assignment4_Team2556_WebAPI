import { useLocation, useNavigate, Link } from "react-router-dom";
import useAuth from "../../hooks/useAuth";
import React from "react";
function DetailsCandidate() {
  const location = useLocation();
  const candidate = location.state.candidateDetails;
  const { auth } = useAuth();

  return (
    <div className="container">
      <h1>Details</h1>

      <div>
        <h5 className="mt-5">
          {/* Details {candidate.firstName} {candidate.lastName} */}
          Candidate
        </h5>

        <table className="table table-bordered ">
          <tbody>

            <tr>
              <th className="col-6">First Name</th>
              <td className="col-6">{candidate.firstName}</td>
            </tr>

            <tr>
              <th className="col-6">Middle Name</th>
              <td className="col-6">{candidate.middleName}</td>
            </tr>

            <tr>
              <th className="col-6">Last Name</th>
              <td className="col-6">{candidate.lastName}</td>
            </tr>

            <tr>
              <th className="col-6">Email</th>
              <td className="col-6">{candidate.email}</td>
            </tr>

            <tr>
              <th className="col-6">Gender</th>
              <td className="col-6">{candidate.gender}</td>
            </tr>

            <tr>
              <th className="col-6">Native Language</th>
              <td className="col-6">{candidate.nativeLanguage}</td>
            </tr>

            <tr>
              <th className="col-6">Birth Date</th>
              <td className="col-6">{candidate.birthDate}</td>
            </tr>

            <tr>
              <th className="col-6">PhotoIdType</th>
              <td className="col-6">{candidate.photoIdType}</td>
            </tr>

            <tr>
              <th className="col-6">PhotoIdNumber</th>
              <td className="col-6">{candidate.photoIdNumber}</td>
            </tr>

            <tr>
              <th className="col-6">PhotoIssueDate</th>
              <td className="col-6">{candidate.photoIssueDate}</td>
            </tr>

            <tr>
              <th className="col-6">Address Line</th>
              <td className="col-6">{candidate.addressLine}</td>
            </tr>

            <tr>
              <th className="col-6">Address Line 2</th>
              <td className="col-6">{candidate.addressLine2}</td>
            </tr>

            <tr>
              <th className="col-6">Country of Residence</th>
              <td className="col-6">{candidate.countryOfResidence}</td>
            </tr>

            <tr>
              <th className="col-6">Province</th>
              <td className="col-6">{candidate.province}</td>
            </tr>

            <tr>
              <th className="col-6">City</th>
              <td className="col-6">{candidate.city}</td>
            </tr>
              
            <tr>
              <th className="col-6">PostalCode</th>
              <td className="col-6">{candidate.postalCode}</td>
            </tr>
              
            <tr>
              <th className="col-6">Landline Number</th>
              <td className="col-6">{candidate.landlineNumber}</td>
            </tr>

            <tr>
              <th className="col-6">Mobile Number</th>
              <td className="col-6">{candidate.mobileNumber}</td>
            </tr>
  
          </tbody>
        </table>
        
        <div>
          <Link
            className="btn btn-secondary"
            to={
              auth?.roles == "Admin"
                ? "../AdminUI/Candidates"
                : "../QualityControlUI/CandidateList"
            }
          >
            Back to List
          </Link>
        </div>
      </div>
    </div>
  );
}

export default DetailsCandidate;
