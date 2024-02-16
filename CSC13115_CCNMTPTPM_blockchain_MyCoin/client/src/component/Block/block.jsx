export default function Block({ name, data, hash, prevHash }) {
  return (
    <div
      style={{
        width: "100%",
        padding: "8px",
        margin: "16px",
        display: "flex",
        flexDirection: "column",
        borderRadius: "8px",
        border: "1px solid #684cff",
        flexWrap: "wrap",
      }}
    >
      <h3 style={{ marginBottom: "4px" }}>{name}</h3>
      <span style={{ marginBottom: "4px" }}>
        <span style={{ fontWeight: "600" }}>Message:</span> {data}
      </span>
      <span style={{ marginBottom: "4px" }}>
        <span style={{ fontWeight: "600" }}>Hash: </span>
        {hash}
      </span>
      <span style={{ marginBottom: "4px" }}>
        <span style={{ fontWeight: "600" }}>Previous Hash: </span>
        {prevHash}
      </span>
    </div>
  );
}
