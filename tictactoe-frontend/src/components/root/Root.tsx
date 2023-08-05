import { useState } from "react";
import { TopBar } from "..";
import { SelectTabData, SelectTabEvent } from "@fluentui/react-components";

export const Root = (props: {
    toggleTheme: () => void
}) => {
    const { toggleTheme } = props;

    // State
    const [selectedTab, setSelectedTab] = useState<string>("game");

    // Functions
    const onSelectedTabChange = (event: SelectTabEvent, data: SelectTabData) => {
        setSelectedTab(data.value as string);
    }

    return (
        <TopBar
            toggleTheme={toggleTheme}
            selectedTab={selectedTab}
            onSelectedTabChange={onSelectedTabChange}
        />
    );
}