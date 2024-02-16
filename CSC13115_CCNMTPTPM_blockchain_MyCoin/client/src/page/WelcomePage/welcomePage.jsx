import { useNavigate } from "react-router-dom";
import "./welcomePage.css";
export default function WelcomePage() {
  const navigate = useNavigate();
  const handleClickCreateWalletBtn = () => {
    navigate("/register", { replace: "true" });
  };
  return (
    <div className="page">
      <div className="card-wrapper">
        <h1 className="logo">MyCoin</h1>
        <p className="slogan">Multiple Chains - One Wallet.</p>
        <p className="welcome_description">
          MyCoin is a wallet that gives you easy access to all things crypto and
          web3. Switch accounts and chains with 1 click.
        </p>
        <div className="btn__wrapper">
          <button
            className="btn welcome_btn"
            onClick={handleClickCreateWalletBtn}
          >
            Create a new wallet
          </button>
          <button className="btn welcome_btn">Restore existing wallet</button>
        </div>
      </div>
    </div>
  );
}
