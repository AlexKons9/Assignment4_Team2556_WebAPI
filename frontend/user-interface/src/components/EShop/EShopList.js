import CertificateCard from './CertificateCard';
import './CertificateCard.css'
import Java from '../Photos/Java.png';
import React, { useState, useEffect } from "react";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import useAuth from "../../hooks/useAuth";
import { useNavigate } from "react-router-dom";
import SuccessModal from "../Modals/SuccessModal"
import Button from 'react-bootstrap/Button';

function EShopList() {

  const [certificates, setCertificates] = useState([]);
  const navigate = useNavigate();
  const axiosPrivate = useAxiosPrivate();
  const { auth } = useAuth();
  const [modalSuccess, setModalSuccess] = useState(false);
  const [credits, setCredits] = useState(0);

  const buttonForModal = <Button onClick={() => navToMyVouchersHandler()} 
                                 variant="outline-success" style= {{ marginRight: 5}}>My Vouchers
                         </Button>

//
// Summary: Fetch the active certificates
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axiosPrivate.get("/api/Certificates/Active");
        console.log(response.data);
        setCertificates(response.data);
      } catch (error) {
        console.error(error);
      }
    };  
    fetchData();
  }, []);


//
// Summary: Fetch the initial Candidate Credits
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axiosPrivate.get(`/api/Users/GetCandidateCredits/${auth.userName}`);
        
        console.log(response.data);
        setCredits(response.data);
      } catch (error) {
        console.error(error);
      }
    };  
    if(auth?.roles) {
      fetchData();
    }
  }, []);

  const navToMyVouchersHandler = () => {
    navigate('/Exams/VouchersList');
  }

  const closeModalHandler = () => {
    setModalSuccess(false);
  }

//
// Summary: Handles the purchase of a certificate
  const purchaseConfirmHandler = async (certificateId, userName) => {
    try {
      if(auth?.roles) { //if a user is logged in
        if(credits >=10) { // AND if a user has more than 10 credits, then proceed with purchase of voucher
          const voucherResponse = await axiosPrivate.post(`api/Vouchers?certificateId=${certificateId}&userName=${userName}`); //fetch voucher
          const voucher = voucherResponse.data;
          const candidateResponse = await axiosPrivate.get(`api/Candidate/${auth.userName}`); //fetch the candidate
          const candidate = candidateResponse.data;
          const newCredits = credits - 10;  //deduct 10 credits for resetting the state of the credits
          candidate.credits = credits - 10;  //deduct 10 credits for resetting the credits in the database
          setCredits(newCredits);  //reset the credits in the state after the deduction
          await axiosPrivate.put(`api/Candidate/${auth.userName}`, candidate);  //reset the credits in the database after the deduction
          setModalSuccess(true); //trigger success modal
        }
        else{ //if user is logged in, but doesn't have enough credits
          alert("You do no have enough credits!")
        }
      }
      else { //if user is not logged in, then redirect to login page
        navigate("/login")
      }
    } catch (error) {
      console.error(error);
      alert("Error the Certificate requested doesn't exist.");
    }
  }
  
  
  

  return (
    <>
    <SuccessModal
            show={modalSuccess}
            body="You successfully purchased this exam! You can find your voucher to 'Exams/Vouchers'!
                  In order to schedule your exam, go to 'Exams/Schedule your next exam' and use your voucher "
            closeModalHandler={closeModalHandler}
            buttonForModal = {buttonForModal}
    ></SuccessModal>
    <h1 id='header-eshop'>Available Certificates</h1>
      {auth?.roles ? <h5><strong>Remaining Credits: {credits}</strong></h5> : <p></p>}
      <div className="container-fluid d-flex justify-content-center">
      <div className='row'>
      {certificates.map((certificate) => (
        <CertificateCard
            userName={auth.userName}
            candidateId={certificate.certificateId}
            key={certificate.certificateId}
            imgSrc={Java}
            title={certificate.title}
            purchaseConfirmHandler = {purchaseConfirmHandler}
            textBody='Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                      sed do eiusmod tempor incididunt ut labore et dolore 
                      magna aliqua. Ut etiam sit amet nisl purus in. 
                      Quis viverra nibh cras pulvinar.'
          ></CertificateCard>        ))}
      </div>
    </div>
    </>
  );
}

export default EShopList;