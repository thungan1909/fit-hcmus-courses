import { useNavigate } from "react-router-dom";
import "./home.css";
import { useEffect, useState } from "react";
import DetailWallet from "../../component/DetailWallet/detailWallet";
import CreateWallet from "../../component/CreateWallet/createWallet";
import ListWallet from "../../component/ListWallet/listWallet";
import Transaction from "../../component/Transaction/transaction";
import { message } from "antd";
import BlockChain from "../../component/BlockChain/blockChain";
const SHA256 = require("crypto-js/sha256");

export default function Home() {
  const maxDifficulty = 2; // should be max at 4 to be fast
  const miningReward = 1;
  const [walletName, setWalletName] = useState("");
  const [isCreateNewWalletState, setIsCreateNewWalletState] = useState(false);
  const [isSendCoinState, setIsSendCoinState] = useState(false);
  const [newTransaction, setNewTransaction] = useState({});
  const [messageApi, contextHolder] = message.useMessage();
  const [history, setHistory] = useState([]);
  const [indexWalletActive, setIndexWalletActive] = useState(0);
  const [listWallets, setListWallets] = useState([
    { id: 0, name: "Ngan", coin: 100, transfer: 0, recieved: 100 },
  ]);
  const [block, setBlock] = useState([
    {
      id: 0,
      data: "Block genesised by system",
      prevHash: "0",
      hash: "0019098dc1a37decb14d0b04cee98f1c5e92c5deeb2b83a42021cfc064ce643f",
      name: "GENESIS BLOCK",
    },
  ]);

  useEffect(() => {
    if (isCreateNewWalletState) {
      createWallet();
      setIsCreateNewWalletState(false);
    }
  }, [isCreateNewWalletState]);

  useEffect(() => {
    if (isSendCoinState) {
      sendCoinWallet();
      setIsSendCoinState(false);
    }
  }, [isSendCoinState]);
  // Function
  const hash = (index, prevHash, maxDificulty) => {
    let nonce = 0;
    while (true) {
      const time = Date.now();
      const hash = index + time + prevHash + nonce;
      const codeHash = SHA256(hash).toString();
      if (
        codeHash.substring(0, maxDifficulty) ===
        Array(maxDifficulty + 1).join("0")
      ) {
        return codeHash;
      }
      nonce++;
    }
  };

  const findMiner = (from, to, max) => {
    if (max <= 2) {
      return -1;
    }
    while (true) {
      const randomIndex = Math.floor(Math.random() * max);
      if (randomIndex !== from && randomIndex !== to) {
        return randomIndex;
      }
    }
  };

  const createWallet = () => {
    const numberWallet = listWallets.length;
    const newWallet = {
      id: numberWallet,
      name: walletName,
      coin: 0,
      transfer: 0,
      recieved: 0,
    };
    let newListWallet = [...listWallets];
    newListWallet.push(newWallet);
    setListWallets(newListWallet);
    setIndexWalletActive(numberWallet);
  };
  const sendCoinWallet = () => {
    const newWallets = [...listWallets];
    let myCoin = newWallets[indexWalletActive].coin;

    // Check the validity of the input amount
    if (
      newTransaction.id === indexWalletActive ||
      newTransaction.coin > myCoin ||
      newTransaction.coin <= 0 ||
      isNaN(newTransaction.coin)
    ) {
      messageApi.open({
        type: "error",
        content: "Invalid transaction! Please try again",
      });
    } else {
      const newId = block.length;
      const _prevHash = block[newId - 1].hash;
      let newListBlock = [...block];
      const newData = `'${newWallets[indexWalletActive].name}' sent to '${
        newWallets[newTransaction.id].name
      }' ${newTransaction.coin} Coin`;
      let newBlock = {
        id: newId,
        data: newData,
        prevHash: _prevHash,
        hash: hash(newId, _prevHash, maxDifficulty),
        name: "BLOCK NUMBER" + newId,
      };

      newListBlock.push(newBlock);
      setBlock(newListBlock);

      newWallets[indexWalletActive].coin = myCoin - newTransaction.coin;
      newWallets[indexWalletActive].transfer += newTransaction.coin;
      newWallets[newTransaction.id].coin =
        newWallets[newTransaction.id].coin + newTransaction.coin;
      newWallets[newTransaction.id].recieved += newTransaction.coin;

      const idMiner = findMiner(
        indexWalletActive,
        newTransaction.id,
        newWallets.length
      );
      let nameMiner = "Not available";
      if (idMiner !== -1) {
        nameMiner = newWallets[idMiner].name;
        newWallets[idMiner].coin += miningReward;
        newWallets[idMiner].recieved += miningReward;
      }
      const newHistory = {
        id: Date.now(),
        to: newWallets[newTransaction.id].name,
        from: newWallets[indexWalletActive].name,
        coin: newTransaction.coin,
        miner: nameMiner,
      };
      let newListHistory = [...history];
      newListHistory.push(newHistory);
      setHistory(newListHistory);
      setListWallets(newWallets);
      // clearDataForm("formsendcoin");
    }
  };

  return (
    <div className="homepage">
      {contextHolder}
      <div className="homepage__content">
        <div className="homepage-row">
          <div className="homepage-column">
            <CreateWallet
              setIsCreateNewWalletState={setIsCreateNewWalletState}
              setWalletName={setWalletName}
            ></CreateWallet>
            <ListWallet
              listWallets={listWallets}
              setIndexWalletActive={setIndexWalletActive}
            />
          </div>
          <div className="homepage-column">
            <DetailWallet wallet={listWallets[indexWalletActive]} />
            <Transaction
              listWallets={listWallets}
              setNewTransaction={setNewTransaction}
              setIsSendCoinState={setIsSendCoinState}
            />
          </div>
        </div>
        <BlockChain blocks={block} history={history} />

        <div className="homepage-row"></div>
      </div>
    </div>
  );
}
