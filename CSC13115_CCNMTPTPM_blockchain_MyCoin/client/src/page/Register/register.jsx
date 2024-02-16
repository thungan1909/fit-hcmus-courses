import { useEffect, useState } from "react";
import { Button, Form, Input } from "antd";
import WalletApi from "../../api/walletApi";

const initialState = {
  walletName: "",
  password: "",
};

export default function Register({ setIsCreateNewWalletState, setWalletName }) {
  const [walletInput, setWalletInput] = useState(initialState);
  const [isRegister, setIsRegister] = useState(false);

  const onFinish = ({ walletName, password }) => {
    setWalletInput({
      walletName,
      password,
    });
    setIsRegister(true);
  };

  // const registerNewWallet = async (req) => {
  //   try {
  //     const response = await WalletApi.createWallet(walletInput);
  //     console.log(response);
  //   } catch (error) {
  //     console.log(error);
  //   }
  // };

  useEffect(() => {
    if (isRegister) {
      // registerNewWallet();
      // handleGenerateWallet();
      setIsRegister(false);
    }
  }, [isRegister]);

  const handleInputChange = (e) => {
    setWalletInput({ ...walletInput, [e.target.name]: e.target.value });
  };

  return (
    <div className="page">
      <div className="card-wrapper">
        <h1 className="title">Create new wallet</h1>
        <Form className="form" onFinish={onFinish} layout="vertical">
          <Form.Item
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
            name="walletName"
            hasFeedback
            rules={[
              {
                required: true,
                message: "This field is required!",
              },
            ]}
            style={{ width: "380px", marginBottom: "8px" }}
          >
            <Input
              placeholder="Input your wallet's name"
              style={{ height: "35px" }}
              value={walletInput.walletName}
              onChange={handleInputChange}
            />
          </Form.Item>
          <Form.Item
            label={
              <label
                style={{
                  color: "var(--primary-color)",
                  fontWeight: "bold",
                }}
              >
                Password
              </label>
            }
            name="password"
            hasFeedback
            rules={[
              {
                required: true,
                message: "This field is required!",
              },
              {
                pattern:
                  "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{6,30}$",
                message:
                  "Your password needs to be between 6 and 30 characters long and contain one uppercase letter, one lowercase, one number and one special character.",
              },
            ]}
            style={{ width: "380px", marginBottom: "8px" }}
          >
            <Input.Password
              // prefix={<LockOutlined className="site-form-item-icon" />}
              type="password"
              placeholder="Your password"
              style={{ height: "35px" }}
              value={walletInput.password}
              onChange={handleInputChange}
            />
          </Form.Item>
          <Form.Item
            name="confirm"
            label={
              <label>
                {" "}
                <label
                  style={{
                    color: "var(--primary-color)",
                    fontWeight: "bold",
                  }}
                >
                  Confirm Password
                </label>
              </label>
            }
            dependencies={["password"]}
            hasFeedback
            rules={[
              {
                required: true,
                message: "This field is required!",
              },
              ({ getFieldValue }) => ({
                validator(_, value) {
                  if (!value || getFieldValue("password") === value) {
                    return Promise.resolve();
                  }
                  return Promise.reject(
                    new Error(
                      "The two passwords that you entered do not match!"
                    )
                  );
                },
              }),
            ]}
            style={{ width: "380px", marginBottom: "8px" }}
          >
            <Input.Password
              // prefix={<LockOutlined className="site-form-item-icon" />}
              placeholder="Confirm password"
              style={{ height: "35px" }}
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
          </Form.Item>
        </Form>
      </div>
    </div>
  );
}
