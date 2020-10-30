import React, { useRef, useEffect } from 'react';
// import sections
import Hero from '../components/sections/Hero';
import FeaturesTiles from '../components/sections/FeaturesTiles';
import FeaturesSplit from '../components/sections/FeaturesSplit';
import Testimonial from '../components/sections/Testimonial';
import Cta from '../components/sections/Cta';

const Home = () => {

  // <div class="calendly-inline-widget" data-url="https://calendly.com/bshpersona/bosch-calendar?primary_color=e37222" style="min-width:320px;height:630px;"></div>
  // <script type="text/javascript" src="https://assets.calendly.com/assets/external/widget.js"></script>

  return (
    <>
      <Hero className="illustration-section-01" />

      
      <div id="schedule_form">
          <div 
            className="calendly-inline-widget"
            data-url="https://calendly.com/bshpersona/irvine?primary_color=e37222"
            style={{ minWidth: '320px', height: '1000px' }} />
        </div>
      <FeaturesTiles />
      <FeaturesSplit invertMobile topDivider imageFill className="illustration-section-02" />
      <Testimonial topDivider />
      <Cta split />
    </>
  );
}

export default Home;