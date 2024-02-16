import "./listWallet.css";
export default function ListWallet({ listWallets, setIndexWalletActive }) {
  const handleClickWalletItem = (id) => {
    setIndexWalletActive(id);
  };
  return (
    <div className="card-wrapper ">
      <h1 className="title">List Wallet</h1>
      <h3>Choose your wallet</h3>
      <div className="listWallet__content">
        {listWallets.map((item) => (
          <span
            className="listWallet__item"
            key={item.id}
            onClick={() => handleClickWalletItem(item.id)}
          >
            {item.name}
          </span>
        ))}
      </div>
    </div>
  );
}
