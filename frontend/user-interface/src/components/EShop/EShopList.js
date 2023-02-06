import CertificateCard from './CertificateCard';
import './CertificateCard.css'
import Java from '../Photos/Java.png';
import React, { useState, useEffect } from "react";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import useAuth from "../../hooks/useAuth";
import { useNavigate } from "react-router-dom";

function EShopList() {

  const [certificates, setCertificates] = useState([]);
  const navigate = useNavigate();
  const axiosPrivate = useAxiosPrivate();
  const { auth } = useAuth();

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
  

  const purchaseConfirmHandler = async (certificateId, userName) => {
    try {
      console.log(certificateId);
      console.log( userName);
      const response = await axiosPrivate.post(`api/Vouchers?certificateId=${certificateId}&userName=${userName}`);
      const voucher = response.data;
      console.log(voucher);
      // navigate("/");
    } catch (error) {
      console.error(error);
      alert("Error the Certificate requested doesn't exist.");
    }
  }
  
  

  return (
    <>
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