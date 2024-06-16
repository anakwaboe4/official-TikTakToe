import { UserAgentApplication, AuthError, CacheLocation } from "msal";

// Msal Configurations

const msalConfig = {
  auth: {
    authority: `https://login.microsoftonline.com/${process.env.REACT_APP_AZUREAD_TENANT_ID ?? ""}`,
    clientId: process.env.REACT_APP_AZUREAD_CLIENT_ID ?? "",
    redirectUri: window.location.origin
  },
  cache: {
    cacheLocation: "localStorage" as CacheLocation,
    storeAuthStateInCookie: true
  }
};

// My API Auth Parameters
export const apiAuthenticationParameters = {
  scopes: [
    `${process.env.REACT_APP_AZUREAD_RESOURCEURI}/access_as_user`
  ]
};

export const msalAuth = new UserAgentApplication(msalConfig);

export const getSsoToken = async (): Promise<string> => {
  let token = "";

  try {
    token = (await msalAuth.acquireTokenSilent(apiAuthenticationParameters)).accessToken;
  } catch (error) {
    if (
      (error as AuthError).errorCode === "consent_required" ||
      (error as AuthError).errorCode === "interaction_required" ||
      (error as AuthError).errorCode === "login_required" ||
      (error as AuthError).errorCode === "user_login_error"
    ) {
      // In case silent token request fails, invoke token by using an interactive method
      msalAuth.acquireTokenRedirect(apiAuthenticationParameters);
    }
  }
  return token;
};
