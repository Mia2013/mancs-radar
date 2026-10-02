import { useAuth } from "../provider/AuthProvider";

const Login = () => {
	const { logIn } = useAuth();

	return <div>Login</div>;
};

export default Login;
