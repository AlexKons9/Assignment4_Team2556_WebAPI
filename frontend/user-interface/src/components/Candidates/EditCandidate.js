import { useLocation, useNavigate, Link } from "react-router-dom";
import {  useState } from "react";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";

function EditCandidate() {
    const location = useLocation();
    const navigate = useNavigate();
    // const [candidate, setCandidate] = useState({firstName: location.state.candidateDetails.firstName,middleName: location.state.candidateDetails.middleName,lastName: location.state.candidateDetails.lastName,
    //     gender: location.state.candidateDetails.gender,nativeLanguage: location.state.candidateDetails.nativeLanguage,birthDate: location.state.candidateDetails.birthDate,
    //     photoIdType: location.state.candidateDetails.photoIdType,photoIdNumber: location.state.candidateDetails.photoIdNumber,photoIssueDate: location.state.candidateDetails.photoIssueDate,
    //     addressLine: location.state.candidateDetails.addressLine,addressLine2: location.state.candidateDetails.addressLine2,countryOfResidence: location.state.candidateDetails.countryOfResidence,
    //     province: location.state.candidateDetails.province,city: location.state.candidateDetails.city,postalCode: location.state.candidateDetails.postalCode,
    //     landlineNumber: location.state.candidateDetails.landlineNumber,mobileNumber: location.state.candidateDetails.mobileNumber});
    const [candidate, setCandidate] = useState(location.state.candidateDetails)
    const axiosPrivate = useAxiosPrivate();


    const handleChange = (event) => {
        const { name, value } = event.target;
        setCandidate({ ...candidate, [name]: value });
        console.log(candidate);
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            await axiosPrivate.put(`/api/Candidate/${candidate.userName}`,candidate);
            alert("Candidate edited successfully!");

            navigate('/AdminUI/Candidates');
        } 
        catch (error) {
            console.error(error);
            alert("Error editing Candidate");
        }
    };

    return (
        <div className="container">
        <h2 className="mb-3">Edit Candidate</h2>
            <form onSubmit={handleSubmit} className="row g-3 mt-3 form-container">
                    <h5>Personal Details</h5>
                    <div className="col-md-6">
                        <label for="name" className="form-label">First Name</label>
                        <input type="text" id="name" name="firstName" className="form-control"  value={candidate.firstName}
                        onChange={handleChange}></input>
                    </div>    
                    <div className="col-md-6">
                        <label for="middle_name" className="form-label">Middle Name</label>
                        <input type="text" id="middle_name" name="middleName" className="form-control" value={candidate.middleName}
                        onChange={handleChange}></input>
                    </div>
                    <div className="col-md-12 mb-3">
                        <label for="last_name" className="form-label">Last Name</label>
                        <input type="text" id="last_name" name="lastName" className="form-control" value={candidate.lastName}
                        onChange={handleChange}></input>
                    </div>
                    <div className="col-md-6">
                        <label for="birth_date" className="form-label"> Birth Date</label>
                        <input type="date" name="birthDate" id="birth_date" className="form-control"
                        value={candidate.birthDate} onChange={handleChange}></input>
                    </div>
                    <div class="col-md-6">
                        <label for="gender" class=" form-label px-2 fw-bold">Gender
                        {/* <span class="text-danger">*</span> */}
                        </label>                                
                        <select class="form-select" id="gender" name="gender" value={candidate.gender} onChange={handleChange} required>                                    
                        <option selected value="">Please Select Gender</option>                                    
                        <option value="male">Male</option>                                    
                        <option value="female">Female</option>                                    
                        <option value="preferNotToSay">Prefer not to say</option>                                
                        </select>                            
                    </div> 
                    <div className="col-md-6">
                        <label for="native_language" className="form-label">Native Language</label>
                        <input type="text" id="native_language" name="nativeLanguage" className="form-control" value={candidate.nativeLanguage} onChange={handleChange}></input>
                    </div>
                    <div class="col-md-6">                                
                    <label for="photoIdType" class="form-label px-2  fw-bold">Photo Id Type</label>      
                    <select class="form-select" id="photoIdType" name="photoIdType" value={candidate.photoIdType} onChange={handleChange}>  
                    <option selected value="">Please Select ID type</option>  
                    <option value="nationalId">National Id</option>                                    
                    <option value="Passport">Passport</option>                                
                    </select>                            
                    </div>   
                    <div className="col-md-6">
                        <label for="id_number" className="form-label">ID Number</label>
                        <input type="text" id="id_number" name="photoIdNumber" className="form-control" value={candidate.photoIdNumber} onChange={handleChange}></input>
                    </div>
                    <div className="col-md-6 mb-5">
                        <label for="id_date" className="form-label">ID Issue Date</label>
                        <input type="date" id="id_date" name="photoIssueDate" className="form-control" value={candidate.photoIssueDate} onChange={handleChange}></input>
                    </div>

                    <h5 className="mt-4">Communication Details</h5>
                    <div className="col-md-12">
                        <label for="email" className="form-label"> Email</label>
                        <input type="email" name="email" id="email" className="form-control" value={candidate.email} onChange={handleChange}></input>
                    </div> 
                    <div className="col-md-6">
                        <label for="address" className="form-label"> Address</label>
                        <input type="text" name="address" id="addressLine" className="form-control" value={candidate.addressLine} onChange={handleChange}></input>
                    </div> 
                    <div className="col-md-6">
                        <label for="address_number" className="form-label"> Address Number</label>
                        <input type="text" name="addressLine2" id="address_number" className="form-control" value={candidate.addressLine2} onChange={handleChange}></input>
                    </div> 
                    <div className="col-md-6">
                        <label for="postal_code" className="form-label"> Postal Code</label>
                        <input id="postal_code" name="postalCode" type="text" pattern="[0-9]*" className="form-control" value={candidate.postalCode} onChange={handleChange}></input>
                    </div> 
                    <div className="col-md-6">
                        <label for="country_residence" className="form-label"> Country of Residence</label>
                        <input type="text" name="countryOfResidence" id="country_residence" className="form-control" value={candidate.countryOfResidence} onChange={handleChange}></input>
                    </div> 
                    <div className="col-md-6">
                        <label for="state" className="form-label">State</label>
                        <input type="text" name="province" id="state" className="form-control" value={candidate.province} onChange={handleChange}></input>
                    </div> 
                    <div className="col-md-6">
                        <label for="city" className="form-label"> City</label>
                        <input type="text" name="city" id="city" className="form-control" value={candidate.city} onChange={handleChange}></input>
                    </div> 
                    <div className="col-md-6">
                        <label for="landline_number" className="form-label"> Landline Number </label>
                        <input id="landline_number" name="landlineNumber" type="tel" className="form-control" value={candidate.landlineNumber} onChange={handleChange}></input>
                    </div> 
                    <div className="col-md-6">
                        <label for="mobile_number" className="form-label"> Mobile Number </label>
                        <input id="mobile_number" name="mobileNumber" type="tel" className="form-control" value={candidate.mobileNumber} onChange={handleChange}></input>
                    </div> 
                   
                    <div className="d-flex">
                        <button type="submit" className="btn btn-primary align-self-start">Edit</button>
                        <Link id="backButton" className='btn btn-secondary align-self-start'  to={"../AdminUI/Candidates"}>Back to List</Link>
                    </div>
                </form>

        </div>
    );
}

export default EditCandidate;