import { Label } from "@fluentui/react-label"
import { UseSettings } from "./UseSettings";

export const Settings = (props: {
    toastControllerId: string;
}) => {
    const {
        toastControllerId,
    } = props;

    const {
        saveSettings
    } = UseSettings(toastControllerId);

    return (
        <Label onClick={saveSettings} weight="semibold">Here come the settings!</Label>
    )
}