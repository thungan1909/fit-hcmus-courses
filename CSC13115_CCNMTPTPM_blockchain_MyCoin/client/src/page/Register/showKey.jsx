// import { useEffect, useState } from "react";
// function generatePrivateKey() {
//   const characters = "0123456789ABCDEF";
//   let privateKey = "";
//   for (let i = 0; i < 64; i++) {
//     const randomIndex = Math.floor(Math.random() * characters.length);
//     privateKey += characters.charAt(randomIndex);
//   }
//   return privateKey;
// }

// function generatePassphrase() {
//   const characters =
//     "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
//   let passphrase = "";
//   for (let i = 0; i < 12; i++) {
//     const randomIndex = Math.floor(Math.random() * characters.length);
//     passphrase += characters.charAt(randomIndex);
//   }
//   return passphrase;
// }

// export default function showKey() {
//   const [privateKey, setPrivateKey] = useState("");
//   const [passphrase, setPassphrase] = useState("");

//   const handleGenerateWallet = () => {
//     const newPrivateKey = generatePrivateKey();
//     const newPassphrase = generatePassphrase();
//     setPrivateKey(newPrivateKey);
//     setPassphrase(newPassphrase);
//   };

//   return (
//     <div>
//       {" "}
//       {privateKey && passphrase && (
//         <div>
//           <p>Private Key: {privateKey}</p>
//           <p>Passphrase: {passphrase}</p>
//         </div>
//       )}
//     </div>
//   );
// }
