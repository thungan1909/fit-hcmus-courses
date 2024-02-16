export default function History({ from, to, coin, miner }) {
  return (
    <div
      style={{
        width: "100%",
        minWidth: "500px",
        padding: "8px",
        margin: "4px",
        display: "flex",
        flexDirection: "column",
        borderRadius: "8px",
        border: "1px solid #684cff",
        flexWrap: "wrap",
      }}
    >
      <span style={{ marginBottom: "4px" }}>
        <span style={{ fontWeight: "600" }}>From:</span> {from}
      </span>
      <span style={{ marginBottom: "4px" }}>
        <span style={{ fontWeight: "600" }}>To: </span>
        {to}
      </span>
      <span style={{ marginBottom: "4px" }}>
        <span style={{ fontWeight: "600" }}>Coin: </span>
        {coin}
      </span>
      <span style={{ marginBottom: "4px" }}>
        <span style={{ fontWeight: "600" }}>Miner:</span> {miner}
      </span>
    </div>
  );
}
