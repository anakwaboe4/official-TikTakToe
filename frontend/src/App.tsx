import React, { useState } from 'react';
import { FluentProvider, webLightTheme, webDarkTheme, Theme } from '@fluentui/react-components';
import { Root } from "./components/"
import { getSsoToken, msalAuth } from './auth/msalAuth';
import { Themes } from './models';
import { useCookies } from './hooks';

export const TicTacToe: React.FC = () => {
  // Hooks
  const { setCookie, getCookie } = useCookies();

  // State
  const [theme, setTheme] = useState<Theme>(webLightTheme);
  const [selectTheme, setSelectedTheme] = useState<Themes>(Themes.Light);

  // Functions
  const toggleTheme = () => {
    if (selectTheme === Themes.Light) {
      setNewCurrentTheme(Themes.Dark);
    } else {
      setNewCurrentTheme(Themes.Light);
    }
  }
  const setNewCurrentTheme = (newTheme: Themes) => {
    switch (newTheme) {
      case Themes.Light:
        setTheme(webLightTheme);
        break;
      case Themes.Dark:
        setTheme(webDarkTheme);
        break;
    }

    setSelectedTheme(newTheme);
    setCookie("TicTacToe.Theme", newTheme);
  }
  const initializeWebApp = async () => {
    if (!msalAuth.getAccount()) {
      msalAuth.loginRedirect();
    }

    let themeCookie = getCookie("TicTacToe.Theme");
    setNewCurrentTheme(themeCookie as Themes);
  };

  // Effect
  React.useEffect(() => {
    initializeWebApp();
  }, []);

  return (
    <FluentProvider theme={theme}>
      <Root
        theme={theme}
        toggleTheme={toggleTheme}
        apiAccessTokenProvider={getSsoToken}
      />
    </FluentProvider>
  )
}
