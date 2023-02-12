import React from 'react';
import image1 from '../img/undraw_approve_qwp7.svg'
import image2 from '../img/undraw_certification_re_ifll.svg'
import image3 from '../img/undraw_my_documents_re_13dc.svg'
import image4 from '../img/undraw_online_test_re_kyfx.svg'
import image5 from '../img/undraw_proud_coder_re_exuy (1).svg'
import image6 from '../img/undraw_pair_programming_re_or4x.svg'

const Homepage = () => {
    return (
        <div className="">
            {/* Main */}
            <section className="p-5 text-center">
                <div className="container-lg">
                    <div className="row">
                        <div className="d-flex">
                            <div className="col-6 mx-3 pt-2 pb-3">
                                <h1 className="pb-4">Discover your Certification Path Today!</h1>
                                <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla necessitatibus at doloremque
                                    repudiandae tenetur eligendi incidunt a. Pariatur, voluptatum ea excepturi nihil quod, velit
                                    perspiciatis officia ullam!Lorem ipsum dolor sit amet consectetur adipisicing elit. Nulla necessitatibus at doloremque
                                    repudiandae tenetur eligendi incidunt a. Pariatur, voluptatum ea excepturi nihil quod, velit
                                    perspiciatis officia ullam.  Lorem ipsum dolor sit amet consectetur adipisicing elit.r, voluptatum ea excepturi nihil quod, velit
                                    perspiciatis officia ullam.  Lorem ipsum dolor sit amet.</p>
                            </div>
                            <div className="col-6">
                                <img src={image4} className="img-fluid w-75" />
                                {/* Image from undraw.co  Image name: Online test  */}
                            </div>
                        </div>
                    </div>
                </div>
            </section>

        <hr/>
            {/* Java Foundations */}
            <section className=" p-5 text-center">
                <div className="container-lg">
                    <h1 className="text-center pt-5 pb-5">Our Certifications</h1>

                    <div className="row pb-5">
                        <div className="d-flex">
                            <div className="col-6">
                                <img src={image1} className="img-fluid w-50" />
                                {/* Image from undraw.co  Image name: Online test */}
                            </div>
                            <div className="col-5">
                                <h2 className="mb-4">Java Foundation Certification</h2>
                                <p>Lorem ipsum dolor sit amet consectetur elit. Nulla necessitatibus at doloremque
                                    repudiandae tenetur eligendi incidunt a. Pariatur, voluptatum ea excepturi nihil quod, velit
                                    perspiciatis officia ullam, et quaerat quisquam! perspiciatis officia ullam, et quaerat quisquam!
                                    officia ullam, et quaerat quisquam!et quaerat quisquam! perspiciatis officia ullam, et quaerat quisquam!
                                    officia ullam, et quaerat quisquam!  </p>
                            </div>
                        </div>
                    </div>


                    {/* Java Advanced */}
                    <div className="row pb-5 mt-5">
                        <div className="d-flex">
                            <div className="col-1"></div>
                            <div className="col-5">
                                <h2 className="mb-4">Java Advanced Certification</h2>
                                {/* <h1 className="pb-4">Certificates</h1> */}
                                <p>Lorem ipsum dolor sit amet consectetur elit. Nulla necessitatibus at doloremque
                                    repudiandae tenetur eligendi incidunt a. Pariatur, voluptatum ea excepturi nihil quod, velit
                                    perspiciatis officia ullam, et quaerat quisquam! perspiciatis officia ullam, et quaerat quisquam!
                                    officia ullam, et quaerat quisquam!et quaerat quisquam! perspiciatis officia ullam, et quaerat quisquam!
                                    officia ullam, et quaerat quisquam!  </p>
                            </div>
                            <div className="col-6">
                                <img src={image5} className="img-fluid w-75" />
                                {/* Image from undraw.co  Image name: Online test */}
                            </div>
                            {/* <div className="col-1"></div> */}
                        </div>
                    </div>
                </div>
            </section>



        </div>
    )
}

export default Homepage;