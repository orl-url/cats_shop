import axios from "axios";

class ApiClient {

    constructor() {
        this.axiosInstance = axios.create({
            baseURL: "https://localhost:7083",
            withCredentials: true,
            headers: {
                "Content-type": "application/json",
                "Accept": "application/json"
            }
        });

    }

    async get(url) {
        try {
            const result = await this.axiosInstance.get(url);
            return {
                isSuccess: true,
                data: result.data
            };
        } catch (error) {
            return this.handleError(error);
        }
    }


    async post(url, data) {
        try {
            const result = await this.axiosInstance.post(url, data);
            return {
                isSuccess: true,
                data: result.data
            };
        } catch (error) {
            return this.handleError(error);

        }
    }

    async put(url, data) {
        try {
            const result = await this.axiosInstance.put(url, data);
            return {
                isSuccess: true,
                data: result.data
            };
        } catch (error) {
            return this.handleError(error);

        }
    }
    async delete(url) {
        try {
            const result = await this.axiosInstance.delete(url);
            return {
                isSuccess: true,
                data: result.data
            };
        } catch (error) {
            return this.handleError(error);

        }
    }


    handleError(error) {
        if (axios.isAxiosError(error)) {
            // console.log("Axios error: ", error.response ?? error);
            return {
                isSuccess: false,
                error: error.message
            };
        } else {
            // console.log("Unexpected api error: ", error);
            return {
                isSuccess: false,
                error: error
            };
        }
    }
}

export default new ApiClient();