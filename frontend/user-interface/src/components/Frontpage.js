import React from 'react';
import image1 from '../img/undraw_approve_qwp7.svg'
import image2 from '../img/undraw_certification_re_ifll.svg'
import image3 from '../img/undraw_my_documents_re_13dc.svg'
import image4 from '../img/undraw_online_test_re_kyfx.svg'

const Frontpage = () => {
    return (
        <div className="">
            {/* Main */}
            <section className="p-5 text-center">
                <div className="container">
                    <div className="d-flex align-items-center">
                        <div className="col-5 mx-3">
                            <h2 className="pb-3">Student Certificates</h2>
                            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla necessitatibus at doloremque
                                repudiandae tenetur eligendi incidunt a. Pariatur, voluptatum ea excepturi nihil quod, velit
                                perspiciatis officia ullam!</p>
                        </div>
                        <div className="col-2"v></div>
                        <div className="col-5">
                            <img src={image4} className="img-fluid" />
                            {/* Image from undraw.co  Image name: Online test  */}
                        </div>
                    </div>
                </div>
            </section>

            {/* Java Foundations */}
            <section className=" p-5 text-start">
                <div className="container">
                    <div className="d-flex align-items-center justify-content-between border-bottom p-5">
                        <div className="">
                            <img src={image1} className="img-fluid w-75" />
                            {/* Image from undraw.co  Image name: Online test */}
                        </div>
                        <div className="col-6">
                            <h2>Java Foundation</h2>
                            <h2 className="">Certificate</h2>
                            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla necessitatibus at doloremque
                                repudiandae tenetur eligendi incidunt a. Pariatur, voluptatum ea excepturi nihil quod, velit
                                perspiciatis officia ullam, et quaerat quisquam!</p>
                        </div>
                    </div>
                </div>
            </section>

            {/* Java Advanced */}
            <section className="pt-3 pb-5 text-start">
                <div className="container">
                    <div className="d-flex align-items-center justify-content-between border-bottom pb-5">
                        <div className="col-5">
                            <h1>German Language Certificates</h1>
                            {/* <h1 className="pb-4">Certificates</h1> */}
                            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla necessitatibus at doloremque
                                repudiandae tenetur eligendi incidunt a. Pariatur, voluptatum ea excepturi nihil quod, velit
                                perspiciatis officia ullam, et quaerat quisquam!</p>
                        </div>
                        <div className="col-4">
                            <img src="img/undraw_confirm.svg" className="img-fluid w-75" />
                            {/* Image from undraw.co  Image name: Online test */}
                        </div>
                    </div>
                </div>
            </section>



        </div>
    )
}

export default Frontpage;