import React from 'react'
import NavigationBar from '../Components/NavigationPanel/bar.jsx'
import SectionOne from '../Components/SectionOne/sectionone.jsx'
import SectionTwo from '../Components/SectionTwo/sectiontwo.jsx'
import SectionThree from '../Components/SectionThree/sectionthree.jsx'
import SectionFour from '../Components/SectionFour/sectionfour.jsx'
import Footer from '../Components/Footer/footer.jsx'
import './mainpage.css'
const MainPage=()=>{
    return(
        <div className='mainpage'>
            <div>
                 {/* <NavigationBar/> */}
            </div>
            <div>
                <SectionOne/>
            </div>
            <div>
                 <SectionTwo/>
            </div>
            <div>
                <SectionThree/>
            </div>
            <div>
                <SectionFour/>
            </div>     
            <div>
                <Footer/>
            </div>        
        </div>
       
    )
}

export default MainPage;