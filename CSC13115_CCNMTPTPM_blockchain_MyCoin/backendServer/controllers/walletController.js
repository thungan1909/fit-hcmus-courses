const Wallet = require("../models/Wallet");
const bcrypt = require("bcrypt");
const { generateKeyPairSync } = require('crypto');

const walletController = {
  createWallet: async (req, res) => {
    try {
      const { passphrase } = req.body.password; // Lấy passphrase từ request body
      const salt = await bcrypt.genSalt(10);
      const hashedPassword = await bcrypt.hash(req.body.password, salt);
      const { publicKey, privateKey } = generateKeyPairSync("rsa", {
        modulusLength: 2048,
        publicKeyEncoding: {
          type: "spki",
          format: "pem",
        },
        privateKeyEncoding: {
          type: "pkcs8",
          format: "pem",
          passphrase
        },
      });
      //Create new wallet
      const newWallet = new Wallet({
        username: req.body.walletName,
        password: hashedPassword,
        publicKey,
        privateKey,
      });
      //Save wallet to DB
      const wallet = await newWallet.save();
      res.status(200).json(wallet);
    } catch (err) {
        console.error(err);
      res.status(500).json(err);
    }
  },
  loginWallet: async(req, res) => {
    
  }
};
module.exports = walletController;