import CertificateCard from './CertificateCard';
import './CertificateCard.css'
import Java from '../Photos/Java.png';
import React, { useState, useEffect } from "react";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import { Link, useNavigate } from "react-router-dom";

function EShopList() {

  const [certificates, setCertificates] = useState([]);
  const navigate = useNavigate();
  const axiosPrivate = useAxiosPrivate();

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
  
  // fetchData();
  
  

  return (
    <>
    <h1 id='header-eshop'>Available Certificates</h1>
      <div className="container-fluid d-flex justify-content-center">
      <div className='row'>
        <CertificateCard
            imgSrc={Java}
            title="1"//{certificates[0].title}
            textBody='Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                      sed do eiusmod tempor incididunt ut labore et dolore 
                      magna aliqua. Ut etiam sit amet nisl purus in. 
                      Quis viverra nibh cras pulvinar.'
          ></CertificateCard>
          <CertificateCard
            imgSrc={Java}
            title="2"//{certificates[1].title}
            textBody='Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                      sed do eiusmod tempor incididunt ut labore et dolore 
                      magna aliqua. Ut etiam sit amet nisl purus in. 
                      Quis viverra nibh cras pulvinar.'
          ></CertificateCard>
      </div>
    </div>
    </>
  );
}

export default EShopList;