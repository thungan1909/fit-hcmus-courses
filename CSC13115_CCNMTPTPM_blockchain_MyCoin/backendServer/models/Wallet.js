const mongoose = require("mongoose");
const walletSchema = new mongoose.Schema(
  {
    walletName: {
      type: String,
      require: true,
    },
    password: {
      type: String,
      require: true,
      min: 6,
    },
    publicKey: String,
    privateKey: String,
  },
  { timestamps: true }
);
module.exports = mongoose.model("Wallet", walletSchema);
