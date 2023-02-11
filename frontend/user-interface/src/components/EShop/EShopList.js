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

  const buttonForModal = <Button onClick={() => navToMyVouchersHandler()} 
                                 variant="outline-success" style= {{ marginRight: 5}}>My Vouchers
                         </Button>

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

  const navToMyVouchersHandler = () => {
    navigate('/Exams/VouchersList');
  }

  const closeModalHandler = () => {
    setModalSuccess(false);
  }

  const purchaseConfirmHandler = async (certificateId, userName) => {
    try {
      console.log(certificateId);
      console.log( userName);
      if(auth?.roles) {
        const response = await axiosPrivate.post(`api/Vouchers?certificateId=${certificateId}&userName=${userName}`);
        setModalSuccess(true);
        const voucher = response.data;
        console.log(voucher);
        // navigate("/");
      }
      else {
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