import { useRouter } from "next/router";

const Header = () => {

  const router = useRouter();

  const onHeaderItemClicked = (e) => {
    e.preventDefault();
    router.push("/customers");
  }

  return (
    <div id="header">
      <div className="logo-container"> Logo </div>
      <div className="items-container">
        <span className="item" onClick={onHeaderItemClicked}>Customers</span>
      </div>
    </div>
  );
};

export default Header;
