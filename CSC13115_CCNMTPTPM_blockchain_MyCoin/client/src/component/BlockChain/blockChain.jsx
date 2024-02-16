import { useState } from "react";
import Block from "../Block/block";
import History from "../History/history";

export default function BlockChain({ blocks, history }) {
  console.log(blocks);
  const showBlockFromEnd = () => {
    var elements = [];
    for (let i = blocks.length - 1; i >= 0; i--) {
      elements.push(
        <Block
          key={blocks[i].id}
          name={blocks[i].name}
          hash={blocks[i].hash}
          prevHash={blocks[i].prevHash}
          data={blocks[i].data}
        />
      );
    }
    return elements;
  };

  function showHistoryFromEnd(history) {
    var elements = [];
    for (let i = history.length - 1; i >= 0; i--) {
      elements.push(
        <History
          key={history[i].id}
          from={history[i].from}
          to={history[i].to}
          coin={history[i].coin}
          miner={history[i].miner}
        />
      );
    }
    return elements;
  }

  return (
    <>
      <div className="card-wrapper " style={{ width: "1000px" }}>
        <h1 className="title">BlockChain</h1>
        <div>{showBlockFromEnd(blocks)}</div>
      </div>
      <div className="card-wrapper " style={{ width: "1000px" }}>
        <h1 className="title">History</h1>
        <div>{showHistoryFromEnd(history)}</div>
      </div>
    </>
  );
}
