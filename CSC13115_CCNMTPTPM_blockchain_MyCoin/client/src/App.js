import { BrowserRouter, Route, Routes } from "react-router-dom";
import Home from "./page/Home/home";
import WelcomePage from "./page/WelcomePage/welcomePage";
import Register from "./page/Register/register";
import MyWallet from "./page/MyWallet/myWallet";



function App() {
  return <BrowserRouter>
  <Routes>
    <Route path="/welcome" element = {<WelcomePage/>}/>
    <Route path="/home" element={<Home/>}/>
    <Route path="/" element = {<Home/>}/>
    <Route path="/register" element = {<Register/>}/>
    <Route path="/myWallet" element = {<MyWallet/>}/>
    
  </Routes>
  
  </BrowserRouter>;
}

export default App;
