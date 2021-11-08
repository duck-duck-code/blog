import '../styles/globals.css'
import type { AppProps } from 'next/app'
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import { AppBar, Button, Toolbar } from '@mui/material';
import Head from 'next/head'
import { useSession, signIn, signOut } from "next-auth/client";


function MyApp({ Component, pageProps }: AppProps) {
  const [session, loading] = useSession();
  
  return (
    <> 
      <Head>
        <title>Welcum to Blog</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>
      <AppBar position="static">
        <Toolbar>
          {!session && (
            <>
              Not signed 
              <Button onClick={() => signIn()} color="inherit">Sign in</Button>
            </>
          )}
          {session && (
            <>
              Signed in as {session.user?.name}
              <Button onClick={() => signOut()} color="inherit">Sign out</Button>
            </>
          )}
        </Toolbar>
      </AppBar>
      < Component {...pageProps} />
    </>
  );
}

export default MyApp
