import { ErrorResponse } from "../models";

export abstract class WebApiServiceBase {
    constructor(
        private apiEndpoint: string
    ) { }

    protected async executePost<T, B>(action: string, body: B, controller?: AbortController, parameters?: string, asString?: boolean): Promise<T | void> {
        return await this.executeRequest(action, "POST", controller, parameters, asString, JSON.stringify(body));
    }

    protected async executeGet<T>(action: string, controller?: AbortController, parameters?: string, asString?: boolean): Promise<T | void> {
        return await this.executeRequest(action, "GET", controller, parameters, asString);
    }

    protected async executeRequest<T>(action: string, method: string, controller?: AbortController, parameters?: string, asString?: boolean, body?: string | FormData): Promise<T | void> {
        // Build URL
        let urlPathName = `${this.apiEndpoint}${action}`;
        if (parameters) {
            urlPathName += `?${parameters}`;
        }

        // Build headers
        const headers: HeadersInit = { Accept: asString ? "text/plain" : "application/json" }
        if (!(body instanceof FormData)) {
            headers["Content-Type"] = "application/json";
        }

        // Execute fetch
        const response = await fetch(
            urlPathName,
            {
                headers,
                method,
                body,
                signal: controller?.signal
            }
        );

        // Check response
        if (!response.ok) {
            const error: ErrorResponse = await response.json();
            let message = `${error.message}`;
            throw new Error(message);
        }

        if (response.status === 204) {
            return;
        }

        // Return response
        if (asString) {
            return response.text() as unknown as T;
        }
        return response.json();
    }
}