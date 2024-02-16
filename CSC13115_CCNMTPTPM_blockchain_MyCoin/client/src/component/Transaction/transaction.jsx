import { Button, Form, Input, Select } from "antd";
const { Option } = Select;

export default function Transaction({
  listWallets,
  setNewTransaction,
  setIsSendCoinState,
}) {
  const onFinish = (value) => {
    console.log(value);

    const transactionValue = {
      id: Math.floor(value.receiver),
      coin: Math.floor(value.amount),
    };
    setIsSendCoinState(true);
    setNewTransaction(transactionValue);
  };
  if (listWallets) {
    return (
      <div className="card-wrapper ">
        <h1 className="title">Transaction</h1>
        <div className="listWallet__content">
          <Form className="form" onFinish={onFinish} layout="vertical">
            <Form.Item
              name={["receiver"]}
              style={{ width: "320px", margin: "6px 0px" }}
              rules={[{ required: true, message: "Reciever is required" }]}
              label={
                <label
                  style={{
                    color: "var(--primary-color)",
                    fontWeight: "bold",
                  }}
                >
                  Receiver
                </label>
              }
            >
              <Select placeholder="Select receiver">
                {listWallets.map((item) => (
                  <Option
                    value={item.id}
                    className="listWallet__item"
                    key={item.id}
                  >
                    {item.name}
                  </Option>
                ))}
              </Select>
            </Form.Item>
            <Form.Item
              className="input"
              label={
                <label
                  style={{
                    color: "var(--primary-color)",
                    fontWeight: "bold",
                  }}
                >
                  Amount
                </label>
              }
              name="amount"
              hasFeedback
              rules={[
                {
                  required: true,
                  message: "This field is required!",
                },
                {
                  type: Number,
                },
              ]}
              style={{ width: "330px", margin: "6px 0px" }}
            >
              <Input type="number" style={{ height: "35px", width: "100%" }} />
            </Form.Item>

            <Form.Item style={{ marginTop: "56px" }}>
              <Button
                type="primary"
                htmlType="submit"
                className="btn"
                style={{
                  width: "100%",
                  height: "35px",
                  flexDirection: "column",
                  justifyContent: "center",
                  alignItems: "center",
                }}
              >
                Send
              </Button>
            </Form.Item>
          </Form>
        </div>
      </div>
    );
  }
}
