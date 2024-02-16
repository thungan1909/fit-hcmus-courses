import { useState } from "react";
import "./createWallet.css";
import { Button, Form, Input } from "antd";
export default function CreateWallet({
  setIsCreateNewWalletState,
  setWalletName,
}) {
  const [inputWalletName, setInputWalletName] = useState("");
  const [form] = Form.useForm();
  const onFinish = (value) => {
    setWalletName(value.walletname);
    setIsCreateNewWalletState(true);
    resetAllData();
  };
  const resetAllData = () => {
    setInputWalletName({ walletname: "" });
    form.setFieldsValue({
      walletname: "",
    });
  };

  return (
    <div className="card-wrapper">
      <h1 className="title">Create new wallet</h1>

      <Form form={form} className="form" onFinish={onFinish} layout="vertical">
        <Form.Item
          className="input"
          label={
            <label
              style={{
                color: "var(--primary-color)",
                fontWeight: "bold",
              }}
            >
              Wallet's name
            </label>
          }
          name="walletname"
          hasFeedback
          rules={[
            {
              required: true,
              message: "This field is required!",
            },
          ]}
          style={{ marginBottom: "32px", minWidth: "430px" }}
        >
          <Input
            placeholder="Input your wallet's name"
            style={{ height: "35px" }}
            // value={inputValue}
            onChange={(e) => {
              setInputWalletName({
                walletname: e.target.value,
              });
            }}
          />
        </Form.Item>
        <Form.Item style={{ marginTop: "36px" }}>
          <Button
            type="primary"
            htmlType="submit"
            className="btn"
            style={{
              width: "100%",
              marginBottom: "24px",
              height: "35px",
              flexDirection: "column",
              justifyContent: "center",
              alignItems: "center",
            }}
          >
            Create
          </Button>
          {/* Already have an account?{" "}
          <a href="/login" style={{ color: "var(--primary-color)" }}>
            Login
          </a> */}
        </Form.Item>
      </Form>
    </div>
  );
}
