import React, { useState, useEffect } from "react";
import useAxiosPrivate from "../../hooks/useAxiosPrivate";
import useAuth from "../../hooks/useAuth";
import copy from "copy-to-clipboard";


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
        <div className='container-xl'>
            <h1>My Vouchers</h1>
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th scope="col">Voucher Id</th>
                        <th scope="col">Description</th>
                        <th scope="col">Exam</th>
                        <th scope="col"></th>
                    </tr>
                </thead>
                <tbody>
                {vouchers.map((voucher) => (
                    <tr key={voucher.voucherId}>
                        <td scope="row"><h6>{voucher.voucherId}</h6></td>
                        <td scope="row"><h6>{voucher.description}</h6></td>
                        <td scope="row"><h6>{voucher.certificate.title}</h6></td>
                        <td >
                            <button className="btn btn-outline-success" onClick={() => copyToClipboard(voucher.description)}>Copy Voucher</button>
                        </td>
                    </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default VouchersList;