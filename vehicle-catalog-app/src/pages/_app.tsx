import { AppProps } from "next/app"
import { globalStyles } from "../styles/global"
import { Container } from "../styles/pages/app"

globalStyles()

function MyApp({ Component, pageProps }: AppProps) {
  return (
    <Component {...pageProps} />
  )
}

export default MyApp