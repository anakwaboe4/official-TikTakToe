import { createContext, useContext } from "react";
import { IWebApiService } from "../services/interfaces/IWebApiService";

export const WebApiContext = createContext<IWebApiService>({} as IWebApiService);

export const useWebApi = (): IWebApiService => {
    const webApiServiceProvider = useContext(WebApiContext);
    return webApiServiceProvider;
}