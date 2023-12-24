import {
    Button,
    ToastTitle,
    Toast,
    Link,
    ToastTrigger,
} from "@fluentui/react-components";
import { Dismiss16Regular } from "@fluentui/react-icons";

export const DefaultToast = (props: {
    message: string;
}) => {
    const {
        message
    } = props;

    return (
        <Toast>
            <ToastTitle
                action={
                    <ToastTrigger>
                        <Link>
                            <Button
                                appearance="subtle"
                                icon={<Dismiss16Regular />}
                            />
                        </Link>
                    </ToastTrigger>
                }
            >
                {message}
            </ToastTitle>
        </Toast>
    );
}