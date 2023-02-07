import { useLocation, useNavigate, Link } from "react-router-dom";
import React from 'react';
function DetailsCandidate() {
    const location = useLocation();
    const candidate = location.state.candidateDetails;
   
  
    return (
      <div>
        <h1>Details</h1>
  
        <div>
          <h4>Details {candidate.firstName} {candidate.lastName}</h4>
          <hr />
          <dl className="row">
            <dt className="col-sm-2">First Name:</dt>
            <dd className="col-sm-10">{candidate.firstName}</dd>
            <dt className="col-sm-2">Middle Name:</dt>
            <dd className="col-sm-10">{candidate.middleName}</dd>
            <dt className="col-sm-2">Last Name:</dt>
            <dd className="col-sm-10">{candidate.lastName}</dd>
            <dt className="col-sm-2">Email:</dt>
            <dd className="col-sm-10">{candidate.email}</dd>
            <dt className="col-sm-2">Gender:</dt>
            <dd className="col-sm-10">{candidate.gender}</dd>
            <dt className="col-sm-2">Native Language:</dt>
            <dd className="col-sm-10">{candidate.nativeLanguage}</dd>
            <dt className="col-sm-2">Birth Date:</dt>
            <dd className="col-sm-10">{candidate.birthDate}</dd>
            <dt className="col-sm-2">PhotoIdType:</dt>
            <dd className="col-sm-10">{candidate.photoIdType}</dd>
            <dt className="col-sm-2">PhotoIdNumber:</dt>
            <dd className="col-sm-10">{candidate.photoIdNumber}</dd>
            <dt className="col-sm-2">PhotoIssueDate:</dt>
            <dd className="col-sm-10">{candidate.photoIssueDate}</dd>
            <dt className="col-sm-2">Address Line:</dt>
            <dd className="col-sm-10">{candidate.addressLine}</dd>
            <dt className="col-sm-2">Address Line 2:</dt>
            <dd className="col-sm-10">{candidate.addressLine2}</dd>
            <dt className="col-sm-2">Country of Residence:</dt>
            <dd className="col-sm-10">{candidate.countryOfResidence}</dd>
            <dt className="col-sm-2">Province:</dt>
            <dd className="col-sm-10">{candidate.province}</dd>
            <dt className="col-sm-2">City:</dt>
            <dd className="col-sm-10">{candidate.city}</dd>
            <dt className="col-sm-2">PostalCode:</dt>
            <dd className="col-sm-10">{candidate.postalCode}</dd>
            <dt className="col-sm-2">Landline Number:</dt>
            <dd className="col-sm-10">{candidate.landlineNumber}</dd>
            <dt className="col-sm-2">Mobile Number:</dt>
            <dd className="col-sm-10">{candidate.mobileNumber}</dd>
          </dl>  
          <hr />  
            <div>
              <Link className='btn btn-secondary' to="../AdminUI/Candidates">Back to List</Link>
            </div>
  
        </div>
      </div>
    );
  }
  
  export default DetailsCandidate;
  