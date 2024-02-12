import apiService from "@/services/api-service.js";

class CardsService {
  async getCardsAsync() {
    let cards = [];
    const result = await apiService.get('/cards');

    if (result.isSuccess === true) {
      cards = result.data;
    } else {
      console.error("Cant get cards.", result);
    }

    return cards;
  }
}

export default new CardsService();