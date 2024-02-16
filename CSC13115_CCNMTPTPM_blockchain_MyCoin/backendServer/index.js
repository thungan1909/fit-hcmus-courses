const mongoose = require('mongoose');
const express = require('express');
const cors = require('cors');
const app = express();
const dotenv = require("dotenv");
const walletRoute = require("./routes/wallet.js")
dotenv.config();

mongoose.connect(process.env.MONGODB_URL)
  .then(() => {
    console.log("CONNECTED TO MONGO DB");
  })
  .catch((err) => {
    console.log("FAILED TO CONNECT TO MONGO DB", err);
  });
app.use(cors());
app.use(express.json());
//ROUTES
app.use("/v1/wallet", walletRoute);


app.listen(process.env.PORT, () => {
    console.log("Server is running");
  });
  