import { useState } from "react";
import { TopBar } from "..";
import { SelectTabData, SelectTabEvent, Theme } from "@fluentui/react-components";
import styles from "./Root.module.scss";
import { Game, Settings } from "../../tabs";
import { ISettings, Tabs } from "../../models";
import { WebApiContext } from "../../context";
import { IWebApiService } from "../../services/interfaces/IWebApiService";
import { WebApiService } from "../../services/WebApiService";

export const Root = (props: {
    theme: Theme,
    toggleTheme: () => void
}) => {
    const {
        theme,
        toggleTheme
    } = props;

    // State
    const [selectedTab, setSelectedTab] = useState<Tabs>(Tabs.Game);
    const settings: ISettings = {lengthX: 3, lengthY: 3, characters: ["X", "O"]} as ISettings;
    const webApiService: IWebApiService = new WebApiService("http://localhost/");

    // Functions
    const onSelectedTabChange = (event: SelectTabEvent, data: SelectTabData) => {
        setSelectedTab(data.value as Tabs);
    }
    const getTab = () => {
        switch (selectedTab) {
            case Tabs.Game:
                return <Game
                        settings={settings}
                        />
            case Tabs.Settings:
                return <Settings />
        }
    }

    return (
        <WebApiContext.Provider value={webApiService}>
            <div className={styles.container}>
                <TopBar
                    theme={theme}
                    toggleTheme={toggleTheme}
                    selectedTab={selectedTab}
                    onSelectedTabChange={onSelectedTabChange}
                />
                {getTab()}
            </div>
        </WebApiContext.Provider>
    );
}