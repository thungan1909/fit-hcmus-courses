import "./detailWallet.css";
export default function DetailWallet({ wallet }) {
  return (
    <div className="card-wrapper ">
      <h1 className="title">My wallet</h1>
      <span>Wallet's name: {wallet.name}</span>
      <div className="wallet__properties">
        <span className="wallet__property">Coin: {wallet.coin}</span>
        <span className="wallet__property">Transfer: {wallet.transfer}</span>
        <span className="wallet__property">Recieved: {wallet.recieved}</span>
      </div>
    </div>
  );
}
