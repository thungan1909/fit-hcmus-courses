import { useEffect, useState } from "react";
import Web3 from "web3";

const walletContractABI = [
  {
    inputs: [],
    name: "owner",
    outputs: [{ internalType: "address", name: "", type: "address" }],
    stateMutability: "view",
    type: "function",
  },
  {
    inputs: [],
    name: "deposit",
    outputs: [],
    stateMutability: "payable",
    type: "function",
  },
  {
    inputs: [{ internalType: "uint256", name: "_amount", type: "uint256" }],
    name: "withdraw",
    outputs: [],
    stateMutability: "nonpayable",
    type: "function",
  },
  {
    inputs: [],
    name: "getBalance",
    outputs: [{ internalType: "uint256", name: "", type: "uint256" }],
    stateMutability: "view",
    type: "function",
  },
];

export default function MyWallet() {
  const [owner, setOwner] = useState("");
  const [balance, setBalance] = useState(0);
  const [web3, setWeb3] = useState("");
  const [walletContract, setWalletContract] = useState(null);

  useEffect(() => {
    const initWeb3 = async () => {
      if (window.ethereum) {
        const web3 = new Web3(window.ethereum);
        await window.ethereum.enable();
        setWeb3(web3);

        const contractAddress = "<wallet-contract-address>";
        const walletContract = new web3.eth.Contract(
          walletContractABI,
          contractAddress
        );
        setWalletContract(walletContract);

        const owner = await walletContract.methods.owner().call();
        setOwner(owner);

        const balance = await walletContract.methods.getBalance().call();
        setBalance(balance);
      } else {
        console.log("Web3 not found");
      }
    };

    initWeb3();
  }, []);

  const deposit = async () => {
    const amount = web3.utils
      .toBN(web3.utils.toWei("<deposit-amount-in-ether>", "ether"))
      .toString(); // Chuyển đổi số tiền thành đối tượng BN
    const accounts = await web3.eth.getAccounts();
    await walletContract.methods.deposit().send({
      from: accounts[0],
      value: amount.toString(), // Pass the amount as a string
    });
    const newBalance = await web3.eth.getBalance(
      walletContract.options.address
    );
    setBalance(web3.utils.fromWei(newBalance, "ether"));
  };

  const withDraw = async () => {
    const amount = web3.utils.toBN(
      web3.utils.toWei("<withdraw-amount-in-ether>", "ether")
    ); // Chuyển đổi số tiền thành đối tượng BN
    const accounts = await web3.eth.getAccounts();
    try {
      await walletContract.methods.withdraw(amount.toString()).send({
        from: accounts[0],
      });
    } catch (err) {
      console.log(err);
    }

    const newBalance = await web3.eth.getBalance(
      walletContract.options.address
    );
    setBalance(web3.utils.fromWei(newBalance, "ether"));
  };

  return (
    <div>
      <h1>My Wallet</h1>
      <br />
      <p>Owner: {owner}</p>
      <p>Balance: {web3 && web3.utils.fromWei(balance, "ether")} ETH</p>
      <button onClick={deposit}>Deposit</button>
      <button onClick={withDraw}>Withdraw</button>
    </div>
  );
}
