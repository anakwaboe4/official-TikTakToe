export const useCookies = (): {
    getCookie: (name: string) => string,
    setCookie: (name: string, value: string) => void,
} => {
    // Hooks

    // State

    // Functions
    const getCookie = (name: string) => {
        let cookie = document.cookie
            .split("; ")
            .find((row) => row.startsWith(name));
        
        return cookie?.split("=")[1] ?? "";
    }

    const setCookie = (name: string, value: string) => {
        document.cookie = `${name}=${value}`;
    }

    // Effects

    return {
        getCookie,
        setCookie,
    };
}