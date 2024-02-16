import AxiosClient from "./axiosClient";

export default class WalletApi {
    
  static async createWallet(req) {
    try {
      const response = await AxiosClient.post(`wallet/create`, req);
      return response;
    } catch (error) {
      throw error.response;
    }
  }
}