import { useState } from "react";
import { TopBar } from "..";
import { SelectTabData, SelectTabEvent, Theme } from "@fluentui/react-components";
import styles from "./Root.module.scss";
import { Game, Settings } from "../../tabs";
import { Tabs } from "../../models";

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

    // Functions
    const onSelectedTabChange = (event: SelectTabEvent, data: SelectTabData) => {
        setSelectedTab(data.value as Tabs);
    }
    const getTab = () => {
        switch (selectedTab) {
            case Tabs.Game:
                return <Game />
            case Tabs.Settings:
                return <Settings />
        }
    }

    return (
        <div className={styles.container}>
            <TopBar
                theme={theme}
                toggleTheme={toggleTheme}
                selectedTab={selectedTab}
                onSelectedTabChange={onSelectedTabChange}
            />
            {getTab()}
        </div>
    );
}