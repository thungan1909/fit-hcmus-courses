const walletController = require("../controllers/walletController")

const router = require("express").Router();
router.post("/create", walletController.createWallet);


module.exports = router;