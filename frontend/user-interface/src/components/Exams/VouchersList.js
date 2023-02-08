import React, { useState, useEffect } from "react";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import useAuth from "../../hooks/useAuth";
import copy from "copy-to-clipboard";
import CopyToClipboard from "react-copy-to-clipboard";

function VouchersList() {
    
    const [vouchers, setVouchers] = useState([]);
    const { auth } = useAuth();
    const userName = auth.userName;
    const axiosPrivate = useAxiosPrivate();

  
    
     
     const copyToClipboard = (e) => {
        copy(e);
        alert(`You have copied Voucher "${e}" to clipboard`);
     }


    useEffect(() => {
        const fetchData = async () => {
          try {
            const response = await axiosPrivate.get(`api/Vouchers/Candidate?candidateUserName=${userName}`);
            setVouchers(response.data);
          } catch (error) {
            console.error(error);
          }
        };  
        fetchData();
      }, []);


    return (
        <div className='col-md-4 container-fluid justify-content-center'>
            <h1>My Vouchers</h1>
            <table className="table">
                <thead>
                    <tr>
                        <th>Voucher Id</th>
                        <th>Description</th>
                        <th>Exam</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                {vouchers.map((voucher) => (
                    <tr key={voucher.voucherId}>
                    <td>{voucher.voucherId}</td>
                    <td>{voucher.description}</td>
                    <td>{voucher.certificate.title}</td>
                    <td>
                        <button className="btn btn-success" onClick={() => copyToClipboard(voucher.description)}>Copy Voucher</button>
                    </td>
                    </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default VouchersList;